<script>
export default {
  name: "AppContacts",
  data() {
    return {};
  },
  methods: {
    sendMessage() {
      axios
        .post("http://127.0.0.1:8000/api/messages", this.formData)
        .then((response) => {
          //this.formData.userId = "";
          this.formData.name = "";
          this.formData.email = "";
          this.formData.subject = "";
          this.formData.message = "";

          this.errorMessageFound = false;

          // Show the success alert
          this.showMessageAlert = true;
          //Hide the alert after 3 seconds
          setTimeout(() => {
            this.showMessageAlert = false;
          }, 4000);
        })
        .catch((error) => {
          if (error.response) {
            // The request was made and the server responded with a status code
            if (error.response.data.errors) {
              // If errors is an object containing multiple messages
              this.errorMessageFound = true;
              this.errorMessage = Object.values(
                error.response.data.errors
              ).join(", ");
            } else if (error.response.data.message) {
              // If the server sends back a single message
              this.errorMessage = error.response.data.message;
            } else {
              this.errorMessage = "Si è verificato un errore sconosciuto";
            }
          } else if (error.request) {
            // The request was made but no response was received
            this.errorMessage = "Nessuna risposta ricevuta dal server";
          } else {
            // Something happened in setting up the request that triggered an Error
            this.errorMessage = error.message;
          }
        });
    },
  },
};
</script>

<template>
  <h5>Send us a message, we'll get back to you as soon as possible:</h5>

  <form action="" method="POST" @submit.prevent="sendMessage" class="mb-2">
    <div>
      <label for="name" class="col-md-4 col-form-label text-md-right"
        >Nome *</label
      >

      <div>
        <input
          id="name"
          type="text"
          class="form-control"
          name="name"
          v-model="formData.name"
          required
          minlength="3"
          maxlength="50"
          autocomplete="name"
          autofocus
        />
      </div>
    </div>

    <div>
      <label for="email" class="col-md-4 col-form-label text-md-right"
        >Email *</label
      >

      <div>
        <input
          id="email"
          type="email"
          class="form-control"
          name="email"
          v-model="formData.email"
          required
          minlength="3"
          maxlength="500"
          autocomplete="email"
          autofocus
        />
      </div>
    </div>

    <div>
      <label for="subject" class="col-md-4 col-form-label text-md-right"
        >Oggetto del messaggio *</label
      >

      <div>
        <input
          id="subject"
          type="text"
          class="form-control"
          name="subject"
          v-model="formData.subject"
          required
          minlength="3"
          maxlength="100"
          autocomplete="subject"
          autofocus
        />
      </div>
    </div>

    <div>
      <label for="message" class="col-md-4 col-form-label text-md-right"
        >Messaggio *</label
      >

      <div class="mb-3">
        <textarea
          id="message"
          class="form-control"
          name="message"
          v-model="formData.message"
          required
          minlength="3"
          maxlength="500"
        ></textarea>
      </div>
    </div>

    <!-- erros -->
    <div v-if="errorMessageFound">
      {{ errorMessage }}
    </div>

    <div class="mb-3 __main-color">
      I campi contrassegnati con un asterisco sono obbligatori
    </div>

    <button class="btn btn-primary" type="submit">Invia messaggio</button>
  </form>
  <!-- <div v-if="showAlert" class="alert alert-success" role="alert">
  Operazione conclusa con successo!
</div> -->

  <success-alert v-if="showMessageAlert"></success-alert>
</template>
<style lang="scss" scoped></style>

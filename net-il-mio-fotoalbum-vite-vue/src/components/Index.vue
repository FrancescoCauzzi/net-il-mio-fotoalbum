<script>
import axios from "axios";

export default {
  name: "Index",

  data() {
    return {};
  },
  created() {
    this.getPizzas();
  },
  methods: {
    getPizzas() {
      axios
        .get("https://localhost:7249/api/Pizzas/GetPizzas")
        .then((response) => {
          console.log(response.data);
          if (response.data.success) {
            console.log(response.data.pizzaList);
          } else {
            console.log("We did not find any pizza");
          }
        })
        .catch((error) => {
          console.error(error);
        });
    },
  },
};
</script>

<template>
  <div class="__index-ctn">
    <h1>This is my front-end</h1>
  </div>
</template>

<style lang="scss" scoped>
.__index-ctn {
  background-color: gray;
}
</style>

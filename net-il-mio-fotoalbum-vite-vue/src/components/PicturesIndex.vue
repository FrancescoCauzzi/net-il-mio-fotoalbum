<script>
import axios from "axios";

export default {
  name: "Index",

  data() {
    return {
      search: "",
      pictures: [],
      picturesFound: false,
      isLoading: true,
    };
  },
  created() {
    this.getPictures();
  },
  methods: {
    getPictures() {
      axios
        .get("https://localhost:7056/api/Pictures/GetAllPictures")
        .then((response) => {
          console.log(response.data);
          if (response.data.success) {
            console.log(response.data.pictureList);
            this.pictures = response.data.pictureList;
            this.picturesFound = true;
            this.isLoading = false;
          } else {
            console.log("We did not find any picture");
          }
        })
        .catch((error) => {
          console.error(error);
        });
    },
    getPicturesByName() {
      axios
        .get("https://localhost:7056/api/Pictures/SearchPictures", {
          params: { search: this.search },
        })
        .then((response) => {
          console.log(response.data);
          if (response.data.success) {
            console.log(response.data.pictureList);
            this.pictures = response.data.pictureList;
            this.picturesFound = true;
            this.isLoading = false;
          } else {
            console.log("We did not find any picture");
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
    <form class="form-inline my-lg-0 d-flex gap-2 ms-auto">
      <input
        v-model="search"
        class="form-control mr-sm-2"
        type="search"
        placeholder="Search"
        aria-label="Search"
      />
      <button
        class="btn btn-outline-success my-2 my-sm-0"
        type="submit"
        @click.prevent="getPicturesByName"
      >
        <strong> Search </strong>
      </button>
    </form>
    <div
      v-if="isLoading"
      class="text-center py-5 d-flex flex-column align-items-center justify-content-center gap-3 text-white spinner"
    >
      <div>Loading...</div>
      <div id="spinner-container">
        <div class="spinner-border" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
      </div>
    </div>
    <div v-else>
      <div v-if="picturesFound" class="text-center">
        <h1>These are our pictures</h1>
        <div class="__cards-ctn justify-content-center">
          <div v-for="picture in pictures" class="card __card">
            <img :src="picture.imageSrc" class="card-img-top" alt="image" />
            <div class="card-body">
              <h5 class="card-title">{{ picture.name }}</h5>
              <p class="card-text">
                {{ picture.description }}
              </p>
              <!-- <a href="#" class="btn btn-primary">Go somewhere</a> -->
            </div>
          </div>
        </div>
      </div>
      <div v-else>
        <span>We are sorry, we do not have picture to show at the moment</span>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.__index-ctn {
  background-color: gray;
  .__cards-ctn {
    display: flex;
    flex-wrap: wrap;
    gap: 15px;

    .__card {
      min-width: 250px;
      width: calc(100% / 5 * 1 - (15px / 6 * 5));

      img {
        width: 100%;
        height: 250px;
        object-fit: cover;
      }
    }
  }
}
</style>

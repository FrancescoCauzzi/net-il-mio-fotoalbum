<script>
//import Index from "./components/PicturesIndex.vue";
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";

export default {
  name: "App",
  data() {
    return {};
  },

  components: {
    AppHeader,
    AppFooter,
  },
};
</script>

<template>
  <header>
    <AppHeader></AppHeader>
  </header>
  <main>
    <div class="__main-sub-ctn container py-3">
      <router-view></router-view>
    </div>
  </main>
  <footer>
    <AppFooter></AppFooter>
  </footer>
</template>

<style lang="scss" scoped>
$header-height: 60px;
$footer-height: 50px;
@mixin fixed-position {
  position: fixed;
  z-index: 2;
  width: 100%;
}
header {
  height: $header-height;
  @include fixed-position;
}

main {
  background-color: gray;
  min-height: calc(100vh - (#{$header-height}));
  padding-top: $header-height; // Use the variable
  padding-bottom: $header-height; // Use the variable
}

footer {
  @include fixed-position;

  height: $header-height;
  bottom: 0;
  white-space: nowrap;

  background-color: white;
}
</style>

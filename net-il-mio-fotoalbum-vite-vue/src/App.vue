<script>
import Index from "./components/Index.vue";
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";

export default {
  name: "App",
  data() {
    return {};
  },

  components: {
    Index,
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
    <div class="__main-sub-ctn container py-2">
      <Index></Index>
    </div>
  </main>
  <footer>
    <AppFooter></AppFooter>
  </footer>
</template>

<style lang="scss" scoped>
$header-height: 60px;
$footer-height: 50px;
header {
  height: $header-height;
}

main {
  background-color: gray;
  height: calc(100vh - ($header-height + $footer-height));
}

footer {
  height: $footer-height;
}
</style>

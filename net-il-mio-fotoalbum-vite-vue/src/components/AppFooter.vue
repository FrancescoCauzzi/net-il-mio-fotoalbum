<script>
export default {
  name: "AppFooter",

  data() {
    return {};
  },
  computed: {
    currentYear() {
      let currentYear = new Date().getFullYear();
      return currentYear;
    },
  },
};
</script>

<template>
  <footer
    class="d-flex flex-wrap justify-content-between align-items-center px-3"
  >
    <div>
      <span class="text-muted"
        >© {{ currentYear }} C# Course, Boolean - Experis</span
      >
    </div>
    <div>
      <span class="text-muted">Francesco Cauzzi</span>
    </div>
  </footer>
</template>

<style lang="scss" scoped></style>

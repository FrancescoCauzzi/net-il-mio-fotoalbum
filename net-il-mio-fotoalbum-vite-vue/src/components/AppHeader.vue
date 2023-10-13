<script>
export default {
  name: "AppHeader",

  data() {
    return {};
  },
};
</script>

<template>
  <nav
    class="navbar navbar-expand-lg navbar-light bg-light px-3 align-items-center"
  >
    <router-link class="navbar-brand" :to="{ name: 'home' }"
      >Photo Album
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarSupportedContent"
      aria-controls="navbarSupportedContent"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav mr-auto align-items-center">
        <li class="nav-item active">
          <router-link class="nav-link" :to="{ name: 'home' }"
            >Homepage
          </router-link>
        </li>
        <li class="nav-item dropdown">
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-bs-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            Get in touch with us
          </a>
          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <router-link class="nav-link" :to="{ name: 'contacts' }"
              >Contact us
            </router-link>
            <!-- 
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">Another action</a>
            <div class="dropdown-divider"></div>
            <a class="dropdown-item" href="#">Something else here</a> -->
          </div>
        </li>
      </ul>
    </div>
  </nav>
</template>

<style lang="scss" scoped></style>

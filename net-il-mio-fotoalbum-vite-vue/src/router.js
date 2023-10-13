import { createRouter, createWebHistory } from "vue-router";

import PicturesIndex from "./components/PicturesIndex.vue";
import AppContacts from "./components/AppContacts.vue";

const router = createRouter({
  history: createWebHistory(),

  routes: [
    {
      path: "/",
      name: "home",
      component: PicturesIndex,
      meta: {
        title: "Homepage",
      },
    },

    {
      path: "/Contacts/",
      name: "contacts",
      component: AppContacts,
      meta: {
        title: "Contacts",
      },
    },
  ],
});

//modify the label title for each page
router.beforeEach((to) => {
  document.title = to.meta?.title
    ? "Photo-Album - " + to.meta.title
    : "Photo-Album";
});

export { router };

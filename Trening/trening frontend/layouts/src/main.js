import Vue from "vue";
import App from "./App.vue";
import BootstrapVue from "bootstrap-vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.config.productionTip = false;

Vue.use(BootstrapVue);

// här är javascript så kan skapa här ifrån
new Vue({
  render: h => h(App)
}).$mount("#app");

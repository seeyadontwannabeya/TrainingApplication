<template>
  <div id="app">
    <div>
      <!-- Information about navigation: https://bootstrap-vue.js.org/docs/components/navbar/  -->
      <b-navbar toggleable="lg" type="dark" variant="dark">
        <b-navbar-brand href="#" @click="goToPage('HOME')">
          <span>Träning osv.</span>
        </b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item href="#" :disabled="!userSignedIn" @click="goToPage('PROGRAMS')">My Programs</b-nav-item>
            <b-nav-item
              href="#"
              :disabled="!userSignedIn"
              @click="goToPage('APPLICATIONS')"
            >Applications</b-nav-item>

            <b-nav-item
              href="#"
              :disabled="userSignedIn"
              @click="goToPage('REGISTRATION')"
            >Registration</b-nav-item>
          </b-navbar-nav>

          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">
            <div v-if="userSignedIn">
              <b-nav-item-dropdown right>
                <!-- Using 'button-content' slot -->
                <template v-slot:button-content>
                  <em>{{ signedInUser.email }}</em>
                </template>
                <b-dropdown-item @click="signOut">Sign Out</b-dropdown-item>
              </b-nav-item-dropdown>
            </div>
            <div v-else>
              <b-nav-item @click="signIn">Sign in/Sign up</b-nav-item>
            </div>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <div class="body">
      <!-- Note: This is not a good way to navigate through pages, try to implement vue-router instead -->
      <div v-if="selectedPage === 'HOME'">
        <h1>training etc..</h1>

        <p>
          <span>
            This is where you go from
            <img
              src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Stick_Figure.svg/1200px-Stick_Figure.svg.png"
              alt
              style="width:60px; height:80px;"
            /> to this
            <img
              src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Stick_Figure.svg/1200px-Stick_Figure.svg.png"
              alt
              style="width:60px; height:80px;"
            />
          </span>
        </p>

        <br />

        <div class="row">
          <div v-for="(partnerLogoUrl, index) in partners" :key="index" style="margin:10px 20px;">
            <img :src="partnerLogoUrl" alt style="height:100px" />
          </div>
        </div>
      </div>

      <div v-else-if="selectedPage === 'PROGRAMS'"></div>

      <div v-else-if="selectedPage === 'APPLICATIONS'">
        <ApplicationSec />
      </div>

      <div v-else-if="selectedPage === 'REGISTRATION'">
        <UserRegistration />
      </div>
    </div>
  </div>
</template>

<script>
import ApplicationSec from "./ApplicationSec.vue";
import UserRegistration from "./UserRegistration.vue";

export default {
  name: "app",
  components: {
    ApplicationSec,
    UserRegistration
  },

  data: function() {
    return {
      signedInUser: null,
      selectedPage: "HOME"
    };
  },
  methods: {
    signIn: function() {
      console.log("signing in");
      this.signedInUser = {
        email: "namn@mail.com"
      };
    },
    signOut: function() {
      this.signedInUser = null;
      this.goToPage("HOME");
    },
    goToPage(pageName) {
      this.selectedPage = pageName;
    }
  },
  computed: {
    //commputed are like methods but can take no arguments
    userSignedIn: function() {
      return this.signedInUser !== undefined && this.signedInUser !== null;
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #2c3e50;
}

:focus {
  outline: -webkit-focus-ring-color none;
}

.body {
  padding: 8px 16px;
}
</style>

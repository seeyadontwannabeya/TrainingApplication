<template>
  <div id="Registration">
    <h3>Sign up</h3>
    <label for="email">E-mail</label>
    <div id="UserRow">
      <input type="email" id="email" v-model="Email" />
    </div>
    <br />
    <label for="password">Password</label>
    <div id="UserRow">
      <input type="password" id="password" v-model="Password" />
    </div>
    <br />
    <h1>{selectedPage}</h1>
    <br />

    <button type="submit" @click="say(Email, Password)">Submit</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    say: function(Email, Password) {
      console.log(Email + Password);

      axios
        .post("https://localhost:44368/api/UserRegistrations", {
          Email: Email,
          Password: Password
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
        });
    }
  },
  name: "Registration",

  data: function() {
    return {
      Email: "",
      Password: ""
    };
  }
};
</script>
<style>
#UserRegistration {
  text-align: center;
}
.hejsan {
  margin: 10px;
}
</style>

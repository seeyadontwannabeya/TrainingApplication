<template>
  <div id="UserRegistration">
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

    <div id="UserRow1"></div>
    <input type="radio" value="male" id="male" v-model="Gender" />
    <label for="male">Male</label>
    <input type="radio" value="female" id="female" v-model="Gender" />
    <label for="female">Female</label>
    <br />
    <label for="height">How tall are you?</label>
    <div id="UserRow">
      <input type="text" id="height" v-model="Height" />
    </div>
    <br />
    <label for="age">Age?</label>
    <div id="UserRow">
      <input type="text" id="age" v-model="Age" />
    </div>
    <br />
    <label for="weight">How much do you weigh?</label>
    <div id="UserRow">
      <input type="text" id="weight" v-model="Weight" />
    </div>
    <br />
    <span>Activityfactor: {{ Activityfactor }}</span>
    <div class="slidecontainer">
      <input
        type="range"
        min="1.2"
        max="2.0"
        value="1.6"
        step="0.1"
        class="slider"
        id="myRange"
        v-model="Activityfactor"
      />
    </div>
    <button
      type="submit"
      @click="say(Email, Password, Height, Gender, Age, Weight, Activityfactor)"
    >Submit</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    say: function(
      Email,
      Password,
      Height,
      Gender,
      Age,
      Weight,
      Activityfactor
    ) {
      console.log(
        Email + Password + Height + Gender + Age + Weight + Activityfactor
      );
      axios
        .post("https://localhost:44332/api/Registrations", {
          Email: Email,
          Password: Password,
          Height: Height,
          Gender: Gender,
          Age: Age,
          Weight: Weight,
          Activity: Activityfactor
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
        });
      this.name = "";
      this.email = "";
    }
  },
  name: "UserRegistration",

  data: function() {
    return {
      Email: "",
      Password: "",
      Gender: "",
      Age: "",
      Height: "",
      Weight: "",
      Activityfactor: ""
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

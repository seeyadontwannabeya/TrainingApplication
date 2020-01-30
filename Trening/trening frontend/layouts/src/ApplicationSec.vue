<template>
  <div id="ApplicationSec">
    <h3>Training experience</h3>

    <input type="radio" id="firsttime" value="First time" v-model="trainingexperience" />
    <label for="firsttime">Is it your first time working out in a gym?</label>
    <br />
    <input type="radio" id="lessyear" value="Less than a year" v-model="trainingexperience" />
    <label for="lessyear">Have you been working out for less than a year?</label>
    <br />
    <input type="radio" id="moreyear" value="More than a year" v-model="trainingexperience" />
    <label for="moreyear">More than a year</label>
    <br />
    <br />

    <h3>Trainingfrequency</h3>

    <select v-model="trainingdays">
      <option disabled value>Please select one</option>
      <option>1 day/week</option>
      <option>2 days/week</option>
      <option>3 days/week</option>
      <option>4 days/week</option>
      <option>5 days/week</option>
      <option>6 days/week</option>
      <option>7 days/week</option>
    </select>
    <br />
    <br />

    <button type="submit" @click="say(trainingexperience, trainingdays)">Submit</button>

    <!--<h3>Aim/Goal</h3>

    <input type="radio" id="getstrong" value="Get strong" v-model="goals" />
    <label for="getstrong">Do you want to get stronger?</label>

    <div v-if="goals  === 'Get strong'">
      <textarea
        id="muscle"
        value="{muscle}"
        v-model="muscle"
        placeholder="Which muscle/musclegroup?"
      />
    </div>

    <br />
    <input type="radio" id="buildmuscle" value="Build muscle" v-model="goals" />
    <label for="buildmuscle">Bigger?</label>
    <br />

    <br />
    <br />
    <span>Trainingexperience: {{ trainingexperience }}</span>
    <br />
    <span>Trainingfrequency: {{ trainingdays }}</span>
    <br />
    <br />
    <span>Do you have any questions?</span>
    <br />
    <textarea id="message" value="{message}" v-model="message" placeholder="skriv nåt" />

    <button type="submit" @click="say(message, trainingexperience)">Submit</button>-->
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    say: function(trainingexperience, trainingdays) {
      console.log(trainingdays);
      axios
        .post("https://localhost:44368/api/Trainingprograms", {
          TrainingExperience: trainingexperience,
          Trainingdays: trainingdays,
          Goals: ""
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
          console.log(JSON.stringify(response.data));
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
        });
      this.name = "";
      this.email = "";
    }
  },
  name: "ApplicationSec",

  data: function() {
    return {
      trainingexperience: "",
      trainingdays: ""
    };
  }
};
</script>

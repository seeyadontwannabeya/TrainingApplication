<template>
  <div id="NutritionCalculator">
    <h3>Nutrition Calculator</h3>

    <br />
    <label for="age">Age?</label>
    <div id="UserRow">
      <input type="text" id="age" v-model="Age" />
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
    <button type="submit" @click="say(Gender, Age, Height, Weight, Activityfactor)">Submit</button>
    <br />
    <span>Kcal: {{ KcalResult }}</span>
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    say: function(Gender, Age, Height, Weight, Activityfactor) {
      console.log(Gender + Age + Height + Weight + Activityfactor);

      axios
        .post("https://localhost:44368/api/CalcDatas", {
          Gender: Gender,
          Age: Age,
          Height: Height,
          Weight: Weight,
          Activityfactor: Activityfactor
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
          this.KcalResult = response.data.KcalResult;
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
        });
    }
  },
  name: "NutritionCalculator",

  data: function() {
    return {
      Gender: "",
      Age: "",
      Height: "",
      Weight: "",
      Activityfactor: "1.3",
      KcalResult: ""
    };
  }
};
</script>
<style>
#NutritionCalculator {
  text-align: center;
}
</style>

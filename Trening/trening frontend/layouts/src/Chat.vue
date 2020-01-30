<template>
  <div id="Chat">
    <h3>Chat/messages</h3>

    <textarea id="chat_input" value="{message}" v-model="message" placeholder="skriv nåt" />
    <button type="submit" @click="say(message)">Send</button>
    <h1>{{selectedPage}}</h1>
  </div>
</template>

<script>
const app = require("./App");
export default {
  methods: {
    say: function() {
      app.userSignedIn = true;
      console.log(JSON.stringify(app.userSignedIn));
    }
  },
  data: function() {
    return {
      Email: "",
      selectedPage: app
    };
  }
};
</script>


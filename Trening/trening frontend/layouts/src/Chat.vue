<template>
  <div id="Chat">
    <h3>CHAT</h3>

    <textarea id="chat_input" value="{message}" v-model="message" placeholder="skriv nåt" />
    <button type="submit" @click="say(message)">Submit</button>
  </div>
</template>

<script>
export default {
  methods: {
    say: function(message) {
      console.log(message);
    }
  },
  data: function() {
    return {
      Email: ""
    };
  }
};
</script>


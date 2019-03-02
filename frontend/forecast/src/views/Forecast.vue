<template>
  <weatherinput v-on:search:city="searchCity($event)" v-on:search:zip="searchZip($event)"/>
</template>

<script>
import weatherinput from '../components/WeatherInput.vue';

export default {
  components: {
    weatherinput
  },
  methods: {
    searchCity(event) {
      console.log(event)
    },
    searchZip(event) {
      console.log(event)
    }
  }
}
</script>

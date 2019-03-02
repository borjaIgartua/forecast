<template>
  <v-container>   
    <v-alert v-if="error"
                :value="true"
                :key="error"
                type="warning"
              >
              {{ error }}
      </v-alert> 
    <weatherinput v-on:search:city="searchCity($event)" v-on:search:zip="searchZip($event)"/>
    <v-container v-if="loading" bg fill-height grid-list-md text-xs-center>
      <v-layout row wrap align-center>
        <v-flex>
          <v-progress-circular indeterminate color="red" class="text-md-center "></v-progress-circular>
        </v-flex>
      </v-layout>
    </v-container> 
    <transition-group name="fade" tag="ul" class="Results">
      <weatherday v-for="weatherDay in days" :key="weatherDay.day" :wday="weatherDay"/>
    </transition-group>
  </v-container>
</template>

<script>
import weatherinput from '../components/WeatherInput.vue';
import weatherday from '../components/WeatherDay.vue';
const axios = require('axios');

export default {
  data: () => ({
    loading: false, 
    days: [],
    error: null
  }),
  components: {
    weatherinput,
    weatherday
  },
  methods: {
     searchCity(event) {      
      this.search('city', event);
    },
    searchZip(event) {      
      this.search('zipCode', event);
    },
    search(param, value) {
      var query = 'https://localhost:5001/api/weather/forecast?' + param + '=' + value;
      this.error = null;
      this.loading = true;
      this.days = []
      axios
        .get(query)
        .then(response => {
            if (response.data.length > 0) {
              this.days = response.data;

            } else {
              this.error = "Sorry, but we can't find any match for given term :("
            }
        })
        .catch(() => {
          this.error = "We're sorry, we're not able to retrieve this information at the moment, please try back later";
        })
        .finally(() => this.loading = false) //development -> setTimeout(() => this.loading = false, 500)
    } 
  }
}
</script>

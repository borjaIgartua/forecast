<template>
<v-container
        fluid
        grid-list-xs        
        class="pb-0"
      >
        <v-layout row wrap>
          <v-flex xs12>
              <v-card color="blue-grey darken-2" class="white--text">
                <v-card-title>
                    <v-container class="pt-0">
                        <v-container fluid class="pl-0 pt-0">
                            <div class="display-1 font-weight-bold">{{day}}</div>
                        </v-container>
                        <v-layout column>
                            <v-flex>
                                <v-layout row wrap align-content-start>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Temperature</div>
                                    <span class="subheading font-weight-thin">{{temperature}}&deg;</span>
                                </div>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Humidity</div>
                                    <span class="subheading font-weight-thin">{{humidity}}%</span>
                                </div>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Wind</div>
                                    <span class="subheading font-weight-thin">{{speed}}&#32;km/h</span>
                                </div>
                                </v-layout>
                            </v-flex>
                        </v-layout>                        
                    </v-container>
                </v-card-title>
              </v-card>
          </v-flex>
        </v-layout>
</v-container>
</template>

<script>
export default {
    props: ['wday'],
    computed: {
        day() {
            var date = new Date(this.wday.timestamp*1000).toLocaleString(window.navigator.language, {weekday: 'long'});
            var first = date.substring(0,1).toUpperCase();
            var name = date.substring(1);
            return first+name;
        },
        speed() {
            return parseFloat(Math.round(this.wday.wind_speed * 100) / 100).toFixed(2);
        },
        temperature() {
            return parseFloat(Math.round(this.wday.temperature * 100) / 100).toFixed(2);
        },
        humidity() {
            return parseFloat(Math.round(this.wday.humidity * 100) / 100).toFixed(2);
        }
    }
}
</script>



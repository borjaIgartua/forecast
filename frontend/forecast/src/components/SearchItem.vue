<template>
<v-container
        fluid
        grid-list-xs        
        class="pb-0"
      >
        <v-layout row wrap>
          <v-flex xs12>
              <v-card color="cyan light" class="white--text">
                <v-card-title>
                    <v-container class="pt-0">
                        <v-container fluid class="pl-0 pt-0">
                            <div class="display-1 font-weight-bold">{{hsearch.city}}</div>
                        </v-container>
                        <v-container fluid class="pl-0 pt-0">
                            <div class="display-1 font-weight-bold">{{date}}</div>
                        </v-container>
                        <v-btn @click="showDetail=!showDetail">Show detail</v-btn>                                                
                    </v-container>
                    <v-flex xs12>
                    <transition-group name="fade" tag="ul" class="Results">
                        
                        <weatherday v-for="weatherDay in hsearch.days" 
                                    :key="weatherDay.timestamp" 
                                    :wday="weatherDay" 
                                    v-show="showDetail"/>
                        
                    </transition-group>
                    </v-flex>
                </v-card-title>
              </v-card>
          </v-flex>
        </v-layout>
</v-container>
</template>

<script>
import weatherday from '../components/WeatherDay.vue';

export default {
    props: ['hsearch'],
    data: () => ({
        showDetail: false
    }),
    computed: {
        date() {
            var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
            return new Date(this.hsearch.date).toLocaleDateString(navigator.language, options);
        }    
    },
    components: {    
        weatherday
    }
}
</script>
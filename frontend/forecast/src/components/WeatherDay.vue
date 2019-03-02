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
                            <div class="display-1 font-weight-bold">{{wday.day}}</div>
                        </v-container>
                        <v-layout column>
                            <v-flex>
                                <v-layout row wrap align-content-start>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Temperature</div>
                                    <span class="subheading font-weight-thin">{{wday.temperature}}</span>
                                </div>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Humidity</div>
                                    <span class="subheading font-weight-thin">{{wday.humidity}}</span>
                                </div>
                                <div class="pr-5">
                                    <div class="headline font-weight-light">Wind</div>
                                    <span class="subheading font-weight-thin">{{wday.wind_speed}}</span>
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
    props: ['wday']
}
</script>



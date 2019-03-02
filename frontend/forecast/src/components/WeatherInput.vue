<template>
    <v-form @submit.prevent="onSubmit">        
        <v-container>       
            <h2 class="font-weight-regular">Type your search</h2>
            <v-alert v-if="errors.length"
              :value="true"
              type="error"
            >
            Really? don't you see the input error?
            </v-alert> 
            <v-layout>
                <v-flex xs12 md4>
                    <v-text-field
                        v-model="cityName"
                        :rules="cityNameRules"
                        :counter="10"
                        label="City name"
                        required
                    >
                    </v-text-field>        
                </v-flex>
                <v-flex xs12 md4>
                    <v-text-field
                        v-model="zipCode"
                        :rules="zipCodeRules"
                        :counter="5"
                        label="Postal code"
                        required
                    >
                </v-text-field>        
                </v-flex>
                <v-flex>
                    <v-btn :disabled='!isComplete' class="btn btn-primary" type="submit">Search</v-btn>
                </v-flex>
            </v-layout>
        </v-container>
    </v-form>
</template>

<script>
  export default {
    data: () => ({
      cityName: '',
      zipCode: '',
      cityNameRules: [
        v => v.length <= 10 || 'City name must be less than 11 characters'
      ],
      zipCodeRules: [
        v => v.length <= 5 || 'Zip code must be less than 6 characters'
      ],
      errors: []
    }),
    methods: {
      onSubmit () {
        this.errors = []
        if (this.cityName.length > 10) {
          this.errors.push('City name is too long');
        }

        if (this.zipCode.length > 5) {
          this.errors.push('Postal code is too long');
        }

        if (this.errors.length == 0) {
          if (this.cityName.length > 0) { 
            this.$emit('search:city', this.cityName); 
             
          } else if (this.zipCode.length > 0) {
            this.$emit('search:zip', this.zipCode);
          }
        }
      }
    },
    computed: {
        isComplete() {
            if (this.cityName !== '' && this.zipCode !== '') {
                return false;
            }

            if (this.cityName === '' && this.zipCode === '') {
                return false
            }

            return true
        }
    }
  }
</script>
<template>
    <v-form v-model="valid" ref="form" lazy-validation>        
        <v-container>       
            <h2 class="font-weight-regular">Type your search</h2>     
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
      valid: false,
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
      validate () {
        if (!this.$refs.form.validate()) {
            this.errors.push("validate errors");
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
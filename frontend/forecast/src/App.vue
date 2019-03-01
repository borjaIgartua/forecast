<template>
  <v-app>
    <v-toolbar app>
      <v-toolbar-side-icon>
        <img src="https://appsfactory.de/wp-content/themes/appsfactory-2_0/img/favicon/favicon-32x32.png" />
      </v-toolbar-side-icon>
      <v-toolbar-title class="headline text-uppercase">        
        <span>Appsfactory</span>
        <span class="font-weight-light">FORECAST</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn flat to="/">
        <span class="mr-2">Home</span>
      </v-btn>
      <v-btn flat to="/about">
        <span class="mr-2">About</span>
      </v-btn>
    </v-toolbar>
    <v-content>
      <router-view/>
    </v-content>
  </v-app>
</template>



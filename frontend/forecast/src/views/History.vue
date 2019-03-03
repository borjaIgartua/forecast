<template>
  <v-container>
    <transition-group name="fade" tag="ul" class="Results">
      <searchItem v-for="item in searches" :key="item.date" :hsearch="item"/>
    </transition-group>
  </v-container>
</template>

<script>
import searchItem from '../components/SearchItem.vue';

export default {
  data: () => ({
    searches: []
  }),
  mounted() {
    if (localStorage.history) {
      this.searches = JSON.parse(localStorage.history);
    }
  },
  components: {
    searchItem
  },
}
</script>
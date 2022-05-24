<!--
  FileName:   App.vue
  Author:     Eoin Farrell C00164354
  Purpose:    App.vue is the root component for the Sovran Merch store.
              Every view or application route uses this base component to layer
              all of it's specific components onto it.

 -->

<template>
<div class="hero is-fullheight">
  <div class="column">
    <div class="block"></div>
    <div class="container is-widescreen">
      <router-view/>
    </div>
  </div>
</div>
</template>

<style scoped>
.hero{
  background-color: rgb(27, 27, 27);
}
</style>

<script>

export default {
  name: "App",
  components: {
    
  },
  computed: {

  }
};
</script>
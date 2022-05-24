<template>
<div class="container">
  <div class="columns">
    <div class="column">
      <div class="box">
      <HomeContainer @toggleForm="toggleForm"/>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import HomeContainer from '@/components/HomeContainer.vue'
export default {
  name: 'Home',
  components: {
    HomeContainer,
  },
  data() {
    return {
      showForms: true
    }
  },
  methods:{
    toggleForm(){
      console.log("Beep");
    }
  }
}
</script>

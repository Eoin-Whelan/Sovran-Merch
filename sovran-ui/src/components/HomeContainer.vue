<template>
    <div class="container">
      <div class="column">
        <figure class="image is-16by9">
          <img src="../assets/tailor.jpeg" style="z-index: 0;">
        </figure>
        <h1 class="title has-text-black has-text-centered" style="" >Sovran Merch |</h1>
        <h2 class="subtitle has-text-black">A non-profit platform for independent artists</h2>
        <ul>
        <li><h2 class="subtitle has-text-black">Free Registration + Personal Storefront</h2></li>
        <li><h2 class="subtitle has-text-black">Full Stripe Payment Integration</h2></li>
        </ul>
      </div>
          <div class="block"></div>
          <div class="columns is-flex is-centered">
          <figure class='image is-128x128'>
            <img src="../assets/favicon/favicon-store-96.png"/>
          </figure>
          </div>
          <div class="block"></div>
          <div class="block"></div>
          <FormCard/>
          <div class="block"></div>
          <h2 class="subtitle has-text-black is-size-2">Check out our partners:</h2>
          <div class="block"></div>
          <Carousel/>
</div>
</template>

<script>
import FormCard from "@/components/forms/FormCard.vue"
import Carousel from "@/components/forms/Carousel.vue"
export default {
  
  name: 'HomeContainer',
  components: {
    FormCard,
    Carousel
  },
  data(){
    return{
      url_link : "https://google.ie/"
    }
  },
  methods: {

    toggleForm(){
      console.log("Beep");
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

@import url('http://fonts.cdnfonts.com/css/american-typewriter');
h1{
    font-family: 'American Typewriter';
    font-size: 64px;
    margin: 25px;
    z-index: 1;
}

ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #f1c40f;
}
</style>

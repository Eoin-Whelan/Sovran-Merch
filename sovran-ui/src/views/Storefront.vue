<template>
  <div class="container" v-if="show" :style="{ background: backgroundCol }">
      <StoreBanner v-if="show"
        :profilePic= this.profilePic
        :username= this.$route.params.id
        />
  <div class="container">
  <ProductCard
          v-for="(product) in catalog"
          :key="product.name"
          :product='product'
          class="card"
          max
        />
  </div>
  </div>
</template>

<style>
.purple {
    background-color: purple;
}
.dark {
    background-color: grey;
}
.white {
    background-color: white;
}
</style>

<style scoped>
[v-cloak] {
  display: none;
}
</style>

<script>
// :class="[name ? activeClass : '']"
import axios from 'axios';
import ProductCard from '../components/Product/ProductCard.vue'
import StoreBanner from '../components/storefront/StoreBanner.vue'
export default({
  name: 'storefront',
  components: {
    ProductCard,
    StoreBanner
  },
  data () {
    return {
      username: this.$route.params.id,
      contents: [],
      email: "",
      instagram: "",
      twitter: "",
      style: ".purple",
      catalog: [],
      backgroundCol: 'grey',
      profilePic: "",
      show : false
    }
  },
  beforeMount() {
      axios({
        headers: {"Access-Control-Allow-Origin": "*"},
        method: 'get',
        url: '/PullCatalog',
        params: {
            username : this.username,
        }
        }).then(response => { 
            this.contents = response
            this.catalog = response.data.value.catalog
            this.email = response.data.value.email,
            this.profilePic = response.data.value.profileImg
            this.show = true
        })
          .catch(error => {
            console.log(error)
            this.contents = "No matching user found."
        });
  },
  methods: {
    login() {
      axios({
        headers: {"Access-Control-Allow-Origin": "*"},
        method: 'get',
        url: '/pullCatalog',
        params: {
            username : this.username,
        }
        }).then(response => {
          this.contents = response.data;
        })
      }
    }
})

</script>
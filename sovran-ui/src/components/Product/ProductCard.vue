<template>
  <div class="tile is-dark">
    
    <h1>{{product.name}}</h1>
    <div class="columns">
      <div class="column">
        <img :src=product.itemImg onerror="this.src= 'https://res.cloudinary.com/sovran-merch/image/upload/v1650559805/global/ProductImageMissing_zmgohg.png'">
      </div>
    </div>
      <div class="column">
        <div class="content">
          <h1 class="title is-spaced">{{product.itemName}}</h1>
          <p>{{product.itemDesc}}</p>
          <p> Stock ID: {{product.id}}</p>
        </div>
        </div>
        <div class="column is-primary">
          <h1 class="subtitle"><u>Stock Available</u></h1>
          <div v-for="(quantity, size) in product.itemQty" v-bind:key="size">
            <div class="block"></div>
            <ProductButton :measurement="size" :quantity="quantity"></ProductButton>
          </div>
        </div>
    </div>
</template>

<style scoped>

</style>

<script>
import ProductButton from './ProductButton.vue'
export default {
  props: ['product'],
  components: {
    ProductButton
  },
  data () {
    return {
      itemProperties : this.product,
      quantity: this.product.itemQty
    }
  },
  created() {
    console.log(this.product)
  },
}
/*
    <div class="card-body">
      <!-- <i class="icofont-10x icofont-{{icon}}"></i> -->
      <form>
        <div class="row">
          <div class="cell">
            <label>Type:</label>
          </div>
          <div class="cell">
            <em>{{ product.type }}</em>
          </div>
        </div>
        <div class="row">
          <div class="cell">
            <label>Price:</label>
          </div>
          <div class="cell">€{{ product.itemPrice }}</div>
        </div>
        <div class="row">
          <div class="cell">
            <label>Quantity:</label>
          </div>
          <div class="cell">
            <input type="number" v-model.number="quantity"/>
          </div>
        </div>
      </form>
    </div>
    <div class="card-footer">
      <button @click="addToCart(product.name, quantity)" class="btn btn-light">
        Add to cart
      </button>
    </div>
*/
</script>

<template>
  <div>
    <div v-for="products in catalog" class="card">
      <router-link :to="{
        name: 'post',
        params: {
          id: post.id
        },
      }"></router-link>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'products',
    created () {
      this.$store.dispatch('blog/fetchPosts');
    },
    computed: {
      catalog () {
        return this.$store.getters['blog/posts'];
      },
    },
  };
</script>
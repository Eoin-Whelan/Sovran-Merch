<template>
  <div>
    <div>{{ post.title }}</div>
    <div>{{ post.content }}</div>
  </div>
</template>

<script>
  export default {
    name: 'post',
    props: {
      id: {
        type: String,
        required: true,
      },
    },
    computed: {
      posts () {
        return this.$store.getters['blog/posts'];
      },
      // get post with current id from the list
      post () {
        return this.posts.find(post => post.id === Number(this.id));
      },
    },
  };
</script>
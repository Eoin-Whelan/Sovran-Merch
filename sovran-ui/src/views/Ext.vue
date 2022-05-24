<template>
  <div>
    <h1>Redirecting...</h1>
  </div>
</template>

<script>

export default {

  beforeEnter: () => {
    window.location.href = this.$route.params.id;
  }
};
</script>
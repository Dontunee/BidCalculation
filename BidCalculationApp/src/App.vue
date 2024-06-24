<script setup lang="ts">
import AppWelcome from './components/AppWelcome.vue'
import BidCalculator from './components/BidCalculator.vue'
</script>

<template>
  <header>
    <div class="wrapper">
      <AppWelcome />
    </div>
  </header>

  <main>
    <BidCalculator />
  </main>
</template>

<style scoped>
#app {
  font-family: 'Open Sans', sans-serif;
}

header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>

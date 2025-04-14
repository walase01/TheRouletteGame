<template>
  <div class="d-flex">
    <!-- Sidebar -->
    <div class="bg-dark text-white p-3 vh-100" style="width: 220px;">
      <h4 class="mb-4">🎮 Roulette</h4>
      <ul class="nav flex-column">
        <li class="nav-item mb-2">
          <router-link to="/" class="nav-link text-white">Inicio</router-link>
        </li>
        <li class="nav-item mb-2">
          <router-link to="/roulette" class="nav-link text-white">Jugar Ruleta</router-link>
        </li>
      </ul>
    </div>

    <!-- Contenido principal -->
    <div class="p-4 flex-fill animate__animated animate__fadeIn">
      <router-view />
    </div>
  </div>
</template>

<style>
body {
  margin: 0;
}
</style>

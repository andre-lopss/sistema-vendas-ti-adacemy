<template>
  <nav class="navbar navbar-dark bg-dark navbar-expand-lg" data-bs-theme="dark">
    <div class="container-fluid">
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarTogglerDemo01"
        aria-controls="navbarTogglerDemo01"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">      
            <router-link class="nav-link" to="/vendedor/listar">Vendedor</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="nav-link" to="/cliente/listar">Cliente</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="nav-link" to="/servico/listar">Serviço</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="nav-link" to="/pedido/listar">Pedido</router-link> 
          </li>
         
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavBarComponent",
};
</script>
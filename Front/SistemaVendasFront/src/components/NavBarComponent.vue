<template>
  <nav class="navbar bg-primary navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
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
        <a class="navbar-brand" href="#">ViteApp</a>
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#">Home</a>
          </li>
                <li class="nav-item">
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Vendedor
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/vendedor/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/vendedor/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>
          <li>
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Cliente
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/cliente/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/cliente/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>
        </ul>
        <form class="d-flex" role="search">
          <input
            class="form-control me-2"
            type="search"
            placeholder="Pesquisar"
            aria-label="Search"
          />
          <button class="btn btn-outline-dark" type="submit">Pesquisar</button>
        </form>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavBarComponent",
};
</script>
<style scoped>
router-link {
  color: azure;
}
</style>

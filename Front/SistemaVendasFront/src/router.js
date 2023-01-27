import { createWebHistory, createRouter } from "vue-router";

const routes = [
    {
        path: "/vendedor/listar",
        component: () => import("./components/Vendedor/Listar.vue")
    },
    {
        path: "/vendedor/cadastrar",
        component: () => import("./components/Vendedor/Cadastrar.vue")
    },
    {
        path: "/vendedor/atualizar",
        component: () => import("./components/Vendedor/Atualizar.vue")
    }
    ,
    {
        path: "/vendedor/:id",
        component: () => import("./components/Vendedor/Atualizar.vue")
    }
];
const router = createRouter({
    history: createWebHistory(),
    routes
});
export default router;

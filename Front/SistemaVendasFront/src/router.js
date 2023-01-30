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
    },
    {
        path: "/cliente/listar",
        component: () => import("./components/Cliente/Listar.vue")
    },
    {
        path: "/cliente/cadastrar",
        component: () => import("./components/Cliente/Cadastrar.vue")
    },
    {
        path: "/cliente/atualizar",
        component: () => import("./components/Cliente/Atualizar.vue")
    },
    {
        path: "/cliente/:id",
        component: () => import("./components/Cliente/Atualizar.vue")
    },
    {
        path: "/servico/listar",
        component: () => import("./components/Servico/Listar.vue")
    },
    {
        path: "/servico/cadastrar",
        component: () => import("./components/servico/Cadastrar.vue")
    },
    {
        path: "/servico/atualizar",
        component: () => import("./components/Servico/Atualizar.vue")
    }
    ,
    {
        path: "/servico/:id",
        component: () => import("./components/Servico/Atualizar.vue")
    }
];
const router = createRouter({
    history: createWebHistory(),
    routes
});
export default router;

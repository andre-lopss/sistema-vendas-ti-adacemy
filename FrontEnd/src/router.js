import { createWebHistory, createRouter } from "vue-router";

const routes = [
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
        path: "/cliente/atualizar/:id",
        component: () => import("./components/Cliente/Atualizar.vue")
    },
    {
        path: "/cliente/:id",
        component: () => import("./components/Cliente/Listar.vue")
    },
    {
        path: "/cliente/obterId/:id",
        component: () => import('./components/cliente/ListarId.vue')
     },
    // Rotas Vendedor
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
        path: "/vendedor/obterId/:id",
        component: () => import('./components/vendedor/ListarId.vue')
     },
    //Rotas Serviço
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
    },
    {
        path: "/servico/obterId/:id",
        component: () => import('./components/servico/ListarId.vue')
     },
    //Rotas Pedido
    {
        path: "/pedido/listar",
        component: () => import("./components/Pedido/Listar.vue")
    },
    {
        path: "/pedido/cadastrar",
        component: () => import("./components/Pedido/Cadastrar.vue")
    },
    {
        path: "/pedido/atualizar",
        component: () => import("./components/Pedido/Atualizar.vue")
    },
    {
        path: "/pedido/atualizar/:id",
        component: () => import("./components/Pedido/Atualizar.vue")
    },
    {
        path: "/pedido/resumo/:id",
        component: () => import("./components/Pedido/Resumo.vue")
    },
    {
        path: "/pedido/:pedidoId/itemPedido/listar",
        component: () => import('./components/itemPedido/listar.vue')
     },
    {
        path: "/pedido/:pedidoId/itemPedido/cadastrar",
        component: () => import('./components/itemPedido/cadastrar.vue')
    },
    //Rotas Item Pedido
    {
        path: "/itemPedido/listar",
        component: () => import("./components/ItemPedido/Listar.vue")
    },
    {
        path: "/itemPedido/cadastrar",
        component: () => import("./components/ItemPedido/Cadastrar.vue")
    },
    {
        path: "/ItemPedido/atualizar",
        component: () => import("./components/ItemPedido/Atualizar.vue")
    } ,
    {
        path: "/ItemPedido/:id",
        component: () => import("./components/ItemPedido/Atualizar.vue")
    },
];
const router = createRouter({
    history: createWebHistory(),
    routes
});
export default router;

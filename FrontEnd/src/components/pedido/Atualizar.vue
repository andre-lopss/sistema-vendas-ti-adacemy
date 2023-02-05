<template>
    <h3 class="text-center" style="margin-top: 10px;">ATUALIZAR PEDIDO</h3>
    <hr />
    <div class="form" style="padding: 1%;">
        <div class="container col-4">
            <div>
                <label class="form-label">Id</label>
                <input type="text" disabled v-model="pedido.id" class="form-control">
            </div>
            <div>
                <label class="form-label">Data</label>
                <input type="datetime" disabled :value="obterData(pedido.data)" class="form-control">
            </div>
            <div>
                <label class="form-label">Vendedor</label>
                <input type="number" required v-model="pedido.vendedorId" class="form-control">
            </div>
            <div>
                <label class="form-label">Cliente</label>
                <input type="number" required v-model="pedido.clienteId" class="form-control">
            </div>
            <button class="btn btn-success" @click="atualizarPedido" style="margin-top: 4%">Atualizar</button>
        </div>
    </div>
</template>

<script>
import PedidoDataService from '../../services/PedidoDataService';

export default {
    data() {
        return {
            pedido: {}
        }
    },
    methods: {
        obterPedido(id) {
            PedidoDataService.obterPorId(id).then((response) => {
                this.pedido = response.data;
            });
        },
        atualizarPedido() {
            PedidoDataService.atualizar(this.pedido.id, this.pedido).then(() => {
                this.$router.push('listar');
            });
        },
        obterData(data) {
            let dataPedido = new Date(data);
            return dataPedido.toLocaleString();
        }
    },
    mounted() {
        this.obterPedido(this.$route.params.id);
    }
}
</script>
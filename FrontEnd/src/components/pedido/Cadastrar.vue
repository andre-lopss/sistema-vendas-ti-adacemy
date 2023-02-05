<template>
    <h3 class="text-center" style="margin-top: 10px;">CADASTRAR PEDIDO</h3>
    <hr />
    <div class="form" style="padding: 1%;">
        <div class="container col-8">
            <div>
                <label class="form-label">Data</label>
                <input type="text" disabled :value="obterData(dataForm)" class="form-control">
            </div>
            <div>
                <label class="form-label">Vendedor</label>
                <input type="number" required v-model="pedido.vendedorId" class="form-control">
            </div>
            <div>
                <label class="form-label">Cliente</label>
                <input type="number" required v-model="pedido.clienteId" class="form-control">
            </div>
            <button class="btn btn-success" @click="cadastrarPedido" style="margin-top: 4%">Cadastrar</button>
        </div>
    </div>
</template>

<script>
import PedidoDataService from '../../services/PedidoDataService';

export default {
    data() {
        return {
            dataForm: new Date(),
            pedido: {
                data: new Date().toISOString(),
                vendedorId: '',
                clienteId: ''
            }
        }
    },
    methods: {
        cadastrarPedido() {         
            var data = {
                data: this.pedido.data,
                vendedorId: this.pedido.vendedorId,
                clienteId: this.pedido.clienteId
            };
            PedidoDataService.cadastrar(data).then(() => {
                this.$router.push('listar');
            });
        },
        obterData(date) {
            let dataLocal = date;
            return dataLocal.toLocaleString();
        }
    }
}
</script>
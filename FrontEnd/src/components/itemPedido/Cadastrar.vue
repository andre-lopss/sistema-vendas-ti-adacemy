<template>
    <div>
        <h3 class="text-center" style="margin-top: 10px;">CADASTRAR ITEM AO PEDIDO {{ this.$route.params.pedidoId }}</h3>
        <hr/>
        <div class="container col-3">
            <div>
                <label class="form-label">N° do Pedido</label>
                <input type="text" disabled :value="this.$route.params.pedidoId" class="form-control"
                    aria-label="Text input with dropdown button">
            </div>
            <div>
                <label class="form-label">Id do serviço: </label>         
                <div class="input-group mb-3">
                    <input type="text" required v-model="itemPedido.servicoId" class="form-control" aria-label="Text input with dropdown button">
                    <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        SERVIÇOS
                    </button>
                    <ul class="dropdown-menu">
                        <option class="dropdown-item" v-for="(servico, index) in servicos" :key="index" :value="servico.id">
                            {{ servico.id }} - {{ servico.nome }}
                        </option>
                    </ul>
                </div>
            </div>
            <div>
                <label class="form-label">Quantidade: </label>
                <input type="number" required v-model="itemPedido.quantidade" class="form-control">
            </div>
            <div>
                <label class="form-label">Valor: </label>
                <input type="number" format="currency" precision="2" required v-model="itemPedido.valor" class="form-control">
            </div>
            <button class="btn btn-success" @click="cadastrarItemPedido" style="margin-top: 4%">Cadastrar</button>
        </div>
    </div>
</template>

<script>
import ItemPedidoDataService from '../../services/ItemPedidoDataService';
import PedidoDataService from '../../services/PedidoDataService';
import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            itemPedido: {
                servicoId: "",
                quantidade: "",
                valor: ""
            },
            pedidos: [],
            servicos: []
        };
    },
    methods: {
        cadastrarItemPedido() {
            var data = {
                pedidoId: this.$route.params.pedidoId,
                servicoId: this.itemPedido.servicoId,
                quantidade: this.itemPedido.quantidade,
                valor: this.itemPedido.valor
            };
            ItemPedidoDataService.cadastrar(data).then(() => {
                this.$router.push('/pedido/' + data.pedidoId + '/itemPedido/listar');
            });
        },
        obterPedidos() {
            PedidoDataService.listar().then(response => {
                this.pedidos = response.data;
            });
        },
        obterServicos() {
            ServicoDataService.listar().then(response => {
                this.servicos = response.data;
            });
        },
    },
    beforeMount() {
        this.obterPedidos();
        this.obterServicos();
    }
}
</script>
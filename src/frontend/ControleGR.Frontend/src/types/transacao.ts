export interface Transacao {
  id: string;
  descricao: string;
  valor: number;
  tipoTransacao: number;
  categoriaId: string;
  pessoaId: string;
}

export interface TotaisPessoa {
  pessoa_id: string;
  nome: string;
  total_receitas: number;
  total_despesas: number;
  saldo: number;
}

export interface Totais {
  total_receitas: number;
  total_despesas: number;
  saldo: number;
  pessoas?: TotaisPessoa[];
}

export interface TotaisCategoriaItem {
  categoria_id: string;
  total_receitas: number;
  total_despesas: number;
  saldo: number;
}

export interface TotaisPorCategoria {
  categorias: TotaisCategoriaItem[];
  total_receitas: number;
  total_despesas: number;
  saldo_liquido: number;
}

export enum TipoTransacao {
  Despesa = 1,
  Receita = 2,
}

export const getTipoTransacaoLabel = (tipo: number) => (tipo === 1 ? "Despesa" : "Receita");
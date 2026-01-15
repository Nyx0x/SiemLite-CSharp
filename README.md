# 🛡️ SIEM Lite (Security Information and Event Management)

Simulador de um sistema de monitoramento de segurança desenvolvido em C#. O projeto emula o fluxo de ingestão, normalização e análise de logs de incidentes em tempo real.

## 📋 Sobre o Projeto

Este projeto foi desenvolvido como parte de um desafio prático de estruturas de dados e tratamento de exceções em .NET. O sistema simula um cenário de **SOC (Security Operations Center)** onde logs brutos de ataques chegam via fila e precisam ser processados para calcular impactos financeiros.

### ⚙️ Funcionalidades

- **Ingestão de Dados:** Utilização de `Queue<string>` (Fila FIFO) para simular a chegada contínua de logs.
- **Normalização:** Parsing de strings brutas para extração de metadados (Sistema de Origem e Valor do Prejuízo).
- **Detecção de Anomalias:** Regras de negócio implementadas com `throw` para identificar valores inconsistentes (ex: prejuízos negativos).
- **Resiliência:** Tratamento robusto de erros com blocos `try/catch/finally` para capturar falhas de formatação ou lógica sem interromper o processamento da fila.

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8.0)
- **Tipo:** Console Application
- **Conceitos:** Collections, Exception Handling, String Manipulation.

## 🚀 Como Rodar

1. Clone o repositório:
   ```bash
   git clone [https://github.com/Nyx0x/SiemLite-CSharp.git](https://github.com/Nyx0x/SiemLite-CSharp.git)

# Atualização Necessária no Backend - ProjetoPescar

## 📋 Resumo
O frontend foi atualizado com uma nova funcionalidade: **Gerar e Enviar Senha para Usuários**. 

Esta funcionalidade permite que um administrador gere uma senha aleatória de 6 caracteres e a envie automaticamente para o email do usuário.

---

## 🔧 Alterações Necessárias

### 1. Novo Endpoint Requerido

**Rota:** `POST /usuario/gerar-senha`

**Descrição:** Gera uma senha aleatória de 6 caracteres e a envia para o email do usuário.

**Request Body:**
```json
{
  "usuarioId": "string",
  "email": "string"
}
```

**Response (Sucesso - 200):**
```json
{
  "sucesso": true,
  "mensagem": "Senha gerada e enviada com sucesso"
}
```

**Response (Erro - 400/500):**
```json
{
  "sucesso": false,
  "mensagem": "Descrição do erro"
}
```

---

## 📝 Requisitos de Implementação

### Funcionalidades Necessárias:

1. **Gerar Senha Aleatória**
   - Gerar uma string aleatória de exatamente **6 caracteres**
   - Pode incluir: números (0-9), letras maiúsculas (A-Z) e minúsculas (a-z)
   - Exemplo: `aB3x8K`

2. **Enviar Email**
   - Enviar um email para o endereço fornecido no request
   - **Assunto recomendado:** "Sua Nova Senha - ProjetoPescar"
   - **Corpo do email recomendado:**
     ```
     Olá [Nome do Usuário],

     Sua nova senha foi gerada:

     Senha: [SENHA_GERADA]

     Por favor, guarde-a em local seguro.

     Atenciosamente,
     ProjetoPescar
     ```

3. **Atualizar Senha no Banco de Dados**
   - Atualizar a senha do usuário no banco de dados
   - **Importante:** Criptografar a senha antes de salvar (usar bcrypt ou similar)
   - Campo: `usuario.senha`

4. **Validações**
   - ✅ Validar se o usuário existe
   - ✅ Validar se o email é válido
   - ✅ Validar se o usuarioId pertence ao email fornecido
   - ✅ Verificar autenticação e autorização (admin only)

5. **Tratamento de Erros**
   - Usuário não encontrado: retornar `404`
   - Email inválido: retornar `400`
   - Erro ao enviar email: retornar `500` com mensagem descritiva
   - Falha ao atualizar banco: retornar `500`

---

## 🔐 Segurança

- ✅ Apenas administradores devem poder chamar este endpoint
- ✅ Validar token JWT no header `Authorization: Bearer <token>`
- ✅ Log de todas as gerações de senha (quem solicitou, quando, para qual usuário)
- ✅ Usar HTTPS em produção
- ✅ Nunca retornar a senha antiga
- ✅ Criptografar a senha antes de salvar no banco

---

## 📧 Configuração de Email

Certifique-se que o backend tem configurado:
- Serviço de email (Gmail, SendGrid, AWS SES, etc.)
- Credenciais de autenticação
- Template de email (ou usar o formato sugerido acima)
- Tempo limite para envio de email

---

## 🧪 Testes Recomendados

```bash
# Test 1: Gerar senha com sucesso
POST /usuario/gerar-senha
Headers: Authorization: Bearer <token_admin>
Body: {
  "usuarioId": "123456",
  "email": "usuario@exemplo.com"
}
Expected: 200 com mensagem de sucesso

# Test 2: Usuário não encontrado
POST /usuario/gerar-senha
Headers: Authorization: Bearer <token_admin>
Body: {
  "usuarioId": "999999",
  "email": "invalido@exemplo.com"
}
Expected: 404

# Test 3: Sem autorização (não admin)
POST /usuario/gerar-senha
Headers: Authorization: Bearer <token_user>
Body: {...}
Expected: 403
```

---

## 📌 Frontend - Detalhes de Integração

### Fluxo da Aplicação:

1. Admin abre a página "Gerenciar Usuários"
2. Clica em "Editar" em um usuário
3. Clica no botão "Gerar e Enviar Senha" (em verde)
4. Frontend envia POST para `/usuario/gerar-senha`
5. Backend gera senha de 6 caracteres
6. Backend envia email para o usuário
7. Backend atualiza a senha no banco
8. Frontend mostra mensagem de sucesso/erro
9. Se sucesso, mensagem desaparece após 5 segundos

### Headers Enviados:
```
POST /usuario/gerar-senha
Authorization: Bearer <token_jwt>
Content-Type: application/json

{
  "usuarioId": "string",
  "email": "string"
}
```

---

## 🚀 Próximos Passos

1. Implementar o endpoint `POST /usuario/gerar-senha` no backend
2. Testar localmente com as chamadas sugeridas
3. Testar integração com o frontend
4. Verificar se o email é recebido corretamente
5. Validar criptografia de senha
6. Fazer testes de segurança

---

## ❓ Dúvidas Frequentes

**P: A senha deve ser temporária?**
R: Não especificamente. A senha gerada fica permanente até o usuário alterá-la.

**P: Preciso notificar o usuário de outro jeito?**
R: O email é a forma principal. Você pode adicionar logs, SMS, etc., conforme necessário.

**P: Qual tamanho da senha?**
R: Exatamente **6 caracteres** conforme solicitado.

**P: Preciso resetar a senha anterior?**
R: Não, apenas substitua pela nova.

---

## 📞 Contato

Para dúvidas sobre a integração, consulte a documentação do frontend em:
`src/app/services/usuario-service.ts`

---

**Versão:** 1.0  
**Data:** 17 de Novembro de 2025  
**Status:** Aguardando Implementação Backend

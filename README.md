# miniFCU C# Server



### A Fazer:


- Relacionar botoes que podem ser ultilizados como atalhos
- Criar rota para alterar o valor de Encrease
- Integracao com a Api do Flight Simulator 


### Feito:


- Criar rota para acionamento dos botões de atalho
- Criar um grupo de atalho como Default
- Repensar forma de listar os grupos de atalhos aberto
- Acesso aos programas em aberto no win
- Acesso aos programas salvos
- Rota para volume de app especifico
- Criar rota para cadastro dos app a serem salvos
- Criar rota para cadastro de novos atalhos
- Arrumar arquivo de AppConfig.cfg
- Criar rota para deletar grupo de atalhos
- Adicionar status e tipo dos leds dos botoes nos grupos de atalho

----------------------------

# Shortcuts Groups

> #### **GET** Create Shortcut Group
> 
> `http://localhost:8085/getshortcutgroup?groupname=Exemple+group`
> 
> |   Param   |  Type  |
> |-----------|--------|
> | groupname | string |

<br>


#### **GET** Read shortcut group

`http://localhost:8085/getshortcutgroup?groupname=Exemple+group`

|   Param   |  Type  |
|-----------|--------|
| groupname | string |

<br>

#### **GET** Update shortcut group buttons

`http://localhost:8085/setshortcutbutton?groupname=MFS&buttonname=hdr&keytopress=A`

|   Param    |  Type  |
|------------|--------|
| groupname  | string |
| buttonname | string |
| keytopress | string |

<br>

#### **GET** Update shortcut group buttons mode

`http://localhost:8085/setshortcutbuttonmode?groupname=Teste2&buttonname=ap&istoggle=true`

|   Param    |  Type   |
|------------|---------|
| groupname  | string  |
| buttonname | string  |
| keytopress | boolean |

<br>
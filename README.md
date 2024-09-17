# miniFCU C# Server

- Linguagem: C#
- Formato de dados: JSON
- Ambiente: Local
- Objetivo: Intermediar comunicação entre Windows e dispositivo físico (miniFCU) via rede local

<br>
<br>

### ✏️ A Fazer:

- [ ] Altera rota de apps salvos para trazer apenas os apps abertos.
- [ ] Criar rota para alterar o valor de Encrease (Entender se fica no server ou no FCU)
- [ ] Integracao com a Api do Flight Simulator

### ☑️ Feito:
✅ Criar rota que traga a lista de shortcuts salvos <br>
✅ Relacionar botoes que podem ser ultilizados como atalhos <br>
✅ Criar rota para acionamento dos botões de atalho <br>
✅ Criar um grupo de atalho como Default <br>
✅ Repensar forma de listar os grupos de atalhos aberto <br>
✅ Acesso aos programas em aberto no win <br>
✅ Acesso aos programas salvos <br>
✅ Rota para volume de app especifico <br>
✅ Criar rota para cadastro dos app a serem salvos <br>
✅ Criar rota para cadastro de novos atalhos <br>
✅ Arrumar arquivo de AppConfig.cfg <br>
✅ Criar rota para deletar grupo de atalhos <br>
✅ Adicionar status e tipo dos leds dos botoes nos grupos de atalho <br>

----------------------------

# Shortcuts Groups

 ### **POST** Create Shortcut Group 
 
 ```
 http://localhost:8085/getshortcutgroup?groupname=Exemple+group
 ```
 
 |   Param   |  Type  |
 |-----------|--------|
 | groupname | string |

<br>


### **GET** Read a shortcut group
```
http://localhost:8085/getshortcutgroup?groupname=Exemple+group
```

|   Param   |  Type  |
|-----------|--------|
| groupname | string |

<br>

### **GET** Get shortcuts groups list
```
http://localhost:8085/getshortcutgroups
```
Get a list of shirtcuts groups available.

<br>

### **PUT** Update shortcut group buttons

```
http://localhost:8085/setshortcutbutton?groupname=Exemple+group&buttonname=hdr&keytopress=A
```

|   Param    |  Type  |
|------------|--------|
| groupname  | string |
| buttonname | string |
| keytopress | string |

<br>

### **PUT** Update shortcut group buttons mode

```
http://localhost:8085/setshortcutbuttonmode?groupname=Exemple+group&buttonname=ap&istoggle=true
```

|   Param    |  Type   |
|------------|---------|
| groupname  | string  |
| buttonname | string  |
|  istoggle  | boolean |

<br>

### **DELETE** Delete shortcut group

```
http://localhost:8085/deleteshortcutgroup?groupname=Exemple+group
```

|   Param    |  Type   |
|------------|---------|
| groupname  | string  |

<br>

### **GET** Buttons list

```
http://localhost:8085/buttonslist
```

Retorna lista de botões que podem ser usados como atalho.

<br>

### **POST** Press key

```
http://localhost:8085/pressbutton?keytopress=NUMLOCK
```

|    Param    |  Type   |
|-------------|---------|
| pressbutton | string  |
| keytopress  | string  |

<br>

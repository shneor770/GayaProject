# GayaProject

## Structure
```
|GayaProject
│   appsettings.json
│   Program.cs
│   README.md
│
├───Controllers
│       ActionCalculateController.cs
│
├───Data
│       ProcessActionDbContext.cs
│
├───Middleware
│       BlockData.cs
│       DiscountOperation.cs
│       DivideOperation.cs
│       MinusOperation.cs
│       ModuloOperation.cs
│       MultiplyOperation.cs
│       Operation.cs
│       PlusOperation.cs
│
├───Models
│       ProcessAction.cs
└───wwwroot
        api.js
        index.html
```

## Documentation
The progrem can get two parameter and excute the following operations: 
- Plus
- Minus
- Multiply
- Divide
- Modulo
- Discount

All data is store and save in database **SQL SERVER**
When the client performs an action data will be displayed on the screen by operation type:
- Result
- Last 3 actions
- Count of current oprations from current month
- Minimum Result of current oprations
- Maximum Result of current oprations
- Avrage Result of current oprations

  ## screenshot
![1](https://github.com/user-attachments/assets/a0e68fef-fab6-43cd-8f1e-e3a7aa8e9ccd)
![2](https://github.com/user-attachments/assets/9d91dea1-60b6-4bed-bb04-baa539602f19)
![3](https://github.com/user-attachments/assets/b47e65a4-af25-44a6-a29e-64f79424f510)
![4](https://github.com/user-attachments/assets/bff1b05a-079c-4efa-9fea-56b6be69fea9)
  

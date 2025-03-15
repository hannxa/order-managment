# Orders Management System
This project is a console-based application for managing orders in a simplified retail or warehouse environment. It provides a user-friendly menu that allows the user to create orders, move orders to different stages (e.g., to the warehouse or shipment), view orders, check customer data, and more.

## Features
- Create Order: Allows users to create a new order by entering product name, amount, customer type, payment method, and delivery address.
- Move Order to Warehouse: Move a selected order to the warehouse.
- Move Order to Shipment: Move a selected order to the shipment stage.
- View Orders: Displays a list of all orders in the system.
- View Product Quantity: Check how much of a particular product is ordered.
- View Customer Data: Display customer details based on their ID.
- Exit: Exit the application safely with a confirmation.
## Getting Started
Prerequisites
- Visual Studio or any other C# IDE.
- .NET Framework 5.0 or higher.
## How to Run
1. Clone or download the repository to your local machine.
2. Open the project using Visual Studio (or your preferred IDE).
3. Build the solution.
4. Press F5 or use the "Start" button to run the program.
## Menu Options
Once the program starts, you will be presented with a menu. The options available are:

- Create a Sample Order: This option allows you to create a new order.
- Move Order to Warehouse: You can transfer an order to the warehouse by providing its ID.
- Move Order to Shipment: Transfer the order to shipment by providing its ID.
- View List of Orders: See a list of all orders in the system.
- View Product Quantity: Check how many of a specific product have been ordered.
- View Customer Data: Display customer details by entering their ID.
- Exit: Exit the program.
## Example Workflow
1. The program presents a menu.
2. You choose the option to create a sample order.
3. Input details such as product name, order amount, customer type, payment method, and delivery address.
4. After order creation, you can move the order to the warehouse, shipment, or just view it.
5. The program allows viewing the order list, customer details, or checking the stock quantity.
## Error Handling
The program provides basic error handling for user input, ensuring that invalid data (like incorrect order IDs, empty inputs, etc.) does not crash the system and also includes units tests


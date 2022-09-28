# InventoryAPI

CACI Coding Exercise 09/28/22

REST API development – Inventory API

Develop and document a REST API service that manages the inventory of auto parts in local warehouses for an auto part store chain. 
Use whatever back-end language and libraries you’d like (Java, Python, Node, .NET, Golang, etc.) 
Focus solely on the API code by providing only an interface (i.e., not the actual implementation) for the data layer, 
which would be implemented in a local database (you could provide a simple mock implementation for testing).

For nomenclature, a model is a specific kind of part (Manufacturer/Model Number), while an item is a physical part in inventory 
that is identified by model. Models are child elements of a “part category”, e.g. transmission, brakes, engine, etc.

Allow for the following API functions:

-List the quantity of items per warehouse given a particular model ID (return type Part) PartController
-List the model name and quantity given an optional warehouse identifier of a specified part category (return Type Models) ModelController
-Given a model ID, store ID and optional warehouse ID, reserve an item for a particular store 
	(i.e., take it out of available inventory) (IActionResult) (PartController)
-Request an email notification (given an email address) when an item arrives at a store (IActionResult) (PartController) and EmailMsg
-Inform inventory system when a part arrives at a store (Scan In Item) (IActionResult) (PartController)
-If familiar, first document the API using the OpenAPI 3.0 (Swagger) standard in either JSON or YAML.

DB Tables / POCOs needed
-Part
	-Id
	-Name
	-ModelId
	-WarehouseId
	-StoreId
	-CategoryId
	-CustomerId
	-AvailableYN
-Warehouse
	-Id
	-Name
	-Address
-Store
	-Id
	-Name
	-Address
-Model
	-Id
	-Name
	-ModelNumber
-Category
	-Id
	-Name
-Customer
	-Id
	-Name
	-Email
	-Phone
	-Address
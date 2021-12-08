// Lesson 23 - Business Rules as Code  - pg. 270

///////////////////////////////////////////////
// 23.1 Specific types in F#  - pg. 271

// 23.1 Specific types in F#

// Listing 23.1 A sample F# record representing a sample customer
// A customer can be contacted by email, phone, or post.

type Customer1 =
  { CustomerId : string
    Email : string
    Telephone : string
    Address : string }


// 23.1.1 Mixing values of the same type

// Listing 23.2 Creating a customer through a helper function  - pg. 272

/// a function that can create a customer, but mixes values of the same type
let createCustomer1 customerId email telephone address =
  { CustomerId = telephone
    Email = customerId
    Telephone = address
    Address = email }

let customer1 =  // oops
    createCustomer1 "C-123" "nicki@myemail.com" "029-293-23" "1 The Street"


// 23.1.2 Single-case discriminated unions  - pg. 272

// Listing 23.3 Creating a wrapper type via a single-case discriminated union
// you can use them as simple wrapper classes to prevent accidentally mixing up values.

type address = Address of string

let myAddress1 = Address "1 The Street"

//let isTheSameAddress1 = (myAddress1 = "1 The Street")  // doesn't compile

// Unwrapping an Address into its raw string as addressData
let (Address addressData) = myAddress1


// Now you try  - pg. 273
// see customers1.fsx


// 23.1.3 Combining discriminated unions  - pg. 275

// Now you try  - pg. 276
// see customers2.txt


// 23.1.4 Using optional values within a domain  - pg. 276
// Customers should have a mandatory primary contact detail and an
// optional secondary contact detail.


/////////////////////////////////////////////////
// 23.2 Encoding business rules with marker types  - pd. 277

// See Customer3.fsx


//////////////////////////////////////////
// 23.3 Results vs. exceptions  - pg. 218

// See Customer3.fsx

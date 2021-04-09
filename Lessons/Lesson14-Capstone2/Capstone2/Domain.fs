namespace Capstone2.Domain

open System

///  Owner of a bank account
type Customer =
    { Name : string }

/// A bank account
type Account =
    { AccountId : Guid
      Owner : Customer
      Balance : decimal }
 
# 3D-library-

# Motivation

I love 3D printing because nothing is more satisfying then having an issue that can be solved with a little thingamajig.

In most situations I know exactly what I want to print in term of measurements, scale and shapes. Today the main way to design 3D shapes is through design software like Fusion 360 or others. There is no problem with design software for 3D design however as someone who loves software i would love to have a design platform that i would be able to interact with through code. like a CLI or as a client in an optimization procedure.

This project is my attempt at building an engine for this purpose. the end goal of this project will be to ship the software in a nugget that will be easily consumed and have a client library that will be simple to use. If this project gets traction i might also build a CLI for it so it could be used across programming languages.

# structure

STL - STL is the main format that i will be using in order to import and export 3D files in this project.
The structure of an STL file is as follows:

Every STL file represents a Solid (you can think of them as shapes but we will here on in refer to them as Solids). Solids a are comprised of any number of Facets (triangles in a three dimensional space). Facets are comprised of three Vertices (points in three dimensional space).

There are more rules on shapes that make them valid for 3D printing like Solids must be "closed"(every facet must have 3 neighbors) and facets must not intersect and a couple more but I wont get into that here.

# Code

I will describe the basic Design employed in this project so anyone reading may follow, this Design may change as the project evolves I will update this chapter needed:

- Data

Data in this project will be represented in data model classes for Solids, Facets and Vertices. These classes will have basic functionality and are mostly for storing data and not for abstracting complex algorithmic procedures.
Things like listing vertices in a a facet of facets in a solid, and basic functions that have to do with the data structure.

In addition this data structure will support the Visitor pattern with an associated Accept method. This pattern will allow the Visitors created in this project to preform the various editing functions that and classic design software would allow.

- Visitors
  The visitors will allow the client to preform many operations on the solid from the basic offset and stretching to centering, selecting and more. they are implemented through the Visitor pattern according to the literature.

- Creation
  I haven't yet decided on how to create basic models, possibly using the Builder and/or Prototype design patterns so clients can build models that they will register and be able to use as models to build upon.

- client

I need to work on the clients description.

# MVP

The minimum viable product for this project is as follows-

- The client must have a defined API that will make simple design possible.

- the construction section must have all basic shapes, cones, cubes, cylinders, spheres, tauruses and a couple of more advanced shapes like gears and screws.

- operations that must be supported - rotation, offset, stretching, selection addition and subtraction of shapes.

- import and export.

# TDD

this project is also implemented in a test oriented way, every feature and every addition will be tested and a testing suite will be second nature to this project.

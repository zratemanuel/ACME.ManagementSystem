# **ACME Management System**

The project involves developing and testing a system that manages student enrollments in courses. The goal is to ensure that all components of the system, such as services and repositories, work correctly both individually and together. I chose to develop in a console so that the manual tests could be done directly since a Frontend was not necessary. To start, set ConsoleApp as StartUp proyect. 

**The testing system covers various types of tests to ensure the functionality of the system.** It includes unit tests that validate the behavior of individual components such as services and repositories, ensuring each unit functions correctly in isolation. Integration tests are also conducted to verify the interaction between components and the overall functionality of the system. These tests use test doubles, specifically mocks, to simulate the behavior of external dependencies. For example, `Mock<IEnrollmentRepository>` and `Mock<ICourseRepository>` are used to simulate the repositories, and `Mock<IPaymentValidator>` is used to validate payments in a controlled environment, without relying on real implementations. This strategy allows testing the system’s logic in a more predictable and isolated setting. Libraries such as xUnit are employed for test execution, and Moq is used for creating and managing test doubles, facilitating the verification of expected functionality and component interaction.

**What things would you have liked to do but didn’t do?**  
I would have liked to develop a REST API or a more extensive architecture, such as one based on Microservices. However, given the time constraints and focus on other aspects of the project, these improvements were not necessary for the moment. Additionally, incorporating more alternative error scenarios into the test cases would have been beneficial.

**What things did you do but you think could be improved or would be necessary to return to them if the project goes ahead?**  
I would like to improve the scope of validations and connections to external services. To optimize the project, it would be ideal to integrate additional validation checks and ensure smooth connectivity with external APIs. Once the project is integrated with an API gateway, further adjustments may be needed to ensure seamless operation.

**What third-party libraries have you used and why?**  
For this project, I primarily used xUnit, Moq, and FluentAssertions for testing. Moq was utilized for mocking dependencies and isolating units of code, and FluentAssertions was employed for its readable assertions, which help in writing clear and maintainable tests.

**How much time have you invested in doing the project and what things have you had to research and what things were new to you?**  
I invested approximately three intensive days in this project. During this period, I had to revisit topics such as console syntax and explore tools like FluentAssertions. These elements were relatively new to me, and understanding them was crucial for ensuring the effectiveness of the testing and overall project execution.

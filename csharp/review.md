I am using DotNet, Visual Studio Code and Nunit to run this; it should be easy to make it run on any machine!

# Rank the issues in what you believe to be the order of importance.

* Adding a head doesn't take into consideration if it has another head. For me, AddHead can cause issues, as if you call AddHead with an existing LinkedList, it'll override the entire list. I feel we should abstract that from the user and only have Add: if the list in empty, it'll put a Node as head; otherwise it'll add one

* If we have a Last(), it makes no sense that Add is searching for the last with a while loop. If at any point we change the implementation to Last because we have a more efficient way, it is better that we call Last() from Add()

* Delete fails when trying delete the last member, as it tries to access Next.Next (which fails). Delete was also missing to change the Node Value

* Added special cases when doing pop and delete of empty Lists, or 1-member lists

# Resolve the issues found with appropriate documentation.

I've added a few comments, and you have plenty of tests covering most of the scenarios I found that were broken

# Implement the method stubs currently in the file.

There is some comments documenting some of the decisions, including places where I would create some Exceptions or raise messages.
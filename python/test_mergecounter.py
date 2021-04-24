import pytest

from mergecounter import merge_counter

def test_example():
    example = {1 : 4, 5 : 2, 3 : 2, 4 : 1, 6 : 1, 9 : 1}
    assert example == merge_counter([1,5,1,1,3,9], [1,3,5,4,6])

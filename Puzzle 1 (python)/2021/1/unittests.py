import os
import sys
import unittest

sys.path.insert(1, os.path.join(sys.path[0], '..\..'))

from solution import solve, solve2

class TestStringMethods(unittest.TestCase):

    def test_upper(self):
        self.assertEqual('foo'.upper(), 'FOO')
    def test_total(self):
        output = solve('./test_input.txt')
        self.assertEqual(7, output);
    def test_total(self):
        output = solve2('./test_input.txt')
        self.assertEqual(5, output);

if __name__ == '__main__':
    unittest.main()
